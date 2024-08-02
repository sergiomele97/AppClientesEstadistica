import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.ensemble import RandomForestRegressor
from sklearn.metrics import mean_squared_error

# Generar fechas
dates = pd.date_range(start='2020-01-01', periods=100, freq='D')

# Generar valores con una ligera tendencia y ruido
np.random.seed(0)
values = 1.10 + 0.0001 * np.arange(100) + np.random.normal(scale=0.002, size=100)

# Crear DataFrame
data = pd.DataFrame({'time': dates, 'value': values})

# Transformación logarítmica
data['log_value'] = np.log(data['value'])

# Crear características de retardos
def create_lag_features(df, lag=5):
    for i in range(1, lag + 1):
        df[f'lag_{i}'] = df['log_value'].shift(i)
    return df

# Añadir características de retardos
data = create_lag_features(data)
data.dropna(inplace=True)

# Preparar los datos para el modelo
X = data[[f'lag_{i}' for i in range(1, 6)]]
y = data['log_value']

# Crear y ajustar el modelo Random Forest
model = RandomForestRegressor(n_estimators=100, random_state=0)
model.fit(X, y)

# Predicción
future_lags = X.iloc[-1:].values
forecast_log = []

for i in range(10):
    next_pred_log = model.predict(future_lags)[0]
    forecast_log.append(next_pred_log)
    future_lags = np.roll(future_lags, -1)
    future_lags[0, -1] = next_pred_log

# Convertir las predicciones de nuevo a la escala original
forecast = np.exp(forecast_log)

# Generar las fechas futuras
future_dates = pd.date_range(start=data['time'].iloc[-1], periods=11, freq='D')[1:]

# Calcular RMSE en la escala logarítmica
train_predictions_log = model.predict(X)
rmse_log = np.sqrt(mean_squared_error(y, train_predictions_log))
print(f'RMSE (logarítmico): {rmse_log:.5f}')

# Calcular RMSE en la escala original
train_predictions = np.exp(train_predictions_log)
rmse = np.sqrt(mean_squared_error(data['value'], train_predictions))
print(f'RMSE (original): {rmse:.5f}')

# Calcular intervalos de confianza
residuals_log = y - train_predictions_log
std_error_log = np.std(residuals_log)

confidence_interval_log = 1.96 * std_error_log  # 95% intervalo de confianza

upper_bound_log = np.array(forecast_log) + confidence_interval_log
lower_bound_log = np.array(forecast_log) - confidence_interval_log

# Convertir los intervalos de confianza a la escala original
upper_bound = np.exp(upper_bound_log)
lower_bound = np.exp(lower_bound_log)

# Visualización
plt.figure(figsize=(10, 6))
plt.plot(data['time'], data['value'], label='Observado')
plt.plot(future_dates, forecast, label='Predicción', color='red')
plt.fill_between(future_dates, lower_bound, upper_bound, color='pink', alpha=0.3, label='95% IC')
plt.legend()
plt.title(f'Predicción del Cambio EUR/USD con Random Forest (RMSE: {rmse:.5f})')
plt.xlabel('Fecha')
plt.ylabel('Cambio EUR/USD')
plt.show()
