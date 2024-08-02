import pandas as pd
import numpy as np
from statsmodels.tsa.arima.model import ARIMA
import matplotlib.pyplot as plt
from sklearn.metrics import mean_squared_error

# Generar un DataFrame de prueba
np.random.seed(0)
date_range = pd.date_range(start='2023-01-01', periods=200, freq='D')
values = np.random.normal(loc=1.1, scale=0.01, size=len(date_range))

df = pd.DataFrame({'fecha': date_range, 'valor': values})

df = df.sort_index()

# Extraer la serie temporal de los valores
ts = df['valor']

# Dividir los datos en entrenamiento y prueba
train = ts[:-10]
test = ts[-10:]

# Ajustar el modelo ARIMA con los datos de entrenamiento
model = ARIMA(train, order=(5, 0, 2))
model_fit = model.fit()

# Predecir los últimos 10 días de los datos existentes
pred_test = model_fit.get_forecast(steps=10)
pred_test_mean = pred_test.predicted_mean
pred_test_ci = pred_test.conf_int()

# Calcular el error de las predicciones
error = mean_squared_error(test, pred_test_mean)
print(f'Mean Squared Error: {error}')

# Reajustar el modelo usando todos los datos para predecir los próximos 10 días
model = ARIMA(ts, order=(5, 0, 2))
model_fit = model.fit()

# Hacer predicciones futuras para los próximos 10 días
pred_future = model_fit.get_forecast(steps=10)
pred_future_mean = pred_future.predicted_mean
pred_future_ci = pred_future.conf_int()

# Visualizar los resultados
plt.figure(figsize=(10, 6))
plt.plot(ts, label='Datos históricos')
plt.plot(pred_test_mean.index, pred_test_mean, color='blue', label='Predicciones (últimos 10 días)')
plt.plot(pred_future_mean.index, pred_future_mean, color='red', label='Predicciones (futuro)')
plt.fill_between(pred_test_ci.index, pred_test_ci.iloc[:, 0], pred_test_ci.iloc[:, 1], color='blue', alpha=0.3, label='IC (últimos 10 días)')
plt.fill_between(pred_future_ci.index, pred_future_ci.iloc[:, 0], pred_future_ci.iloc[:, 1], color='red', alpha=0.3, label='IC (futuro)')
plt.legend()
plt.xlabel('Fecha')
plt.ylabel('Valor')
plt.title(f'Predicciones con ARIMA - MSE: {error:.4f}')
plt.show()
