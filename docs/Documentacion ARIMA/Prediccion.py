import pandas as pd
import matplotlib.pyplot as plt
import statsmodels.api as sm
import numpy as np


# Configuración de los datos
np.random.seed(42)
dates = pd.date_range(start='2010-01-01', periods=120, freq='M')  # 10 años de datos mensuales
atc2_codes = ['H01', 'H02', 'H03', 'H04']  # Códigos ATC de ejemplo
costs = np.random.uniform(1000, 5000, size=len(dates))

# Crear el DataFrame
data = {
    'Date': dates,
    'ATC2': np.random.choice(atc2_codes, size=len(dates)),
    'Cost': costs
}

PBS = pd.DataFrame(data)
# Filtrar datos para corticosteroides
PBS_corti = PBS[PBS['ATC2'] == 'H02']

# Sumar el costo
Cost = PBS_corti['Cost'].sum()
print("Costo total:", Cost)

# Crear una serie temporal con la suma del costo
PBS_corti['Date'] = pd.to_datetime(PBS_corti['Date'])
PBS_corti.set_index('Date', inplace=True)
monthly_cost = PBS_corti['Cost'].resample('M').sum()

# Graficar la serie temporal
plt.figure(figsize=(10, 6))
plt.plot(monthly_cost, label='Costo mensual')
plt.title('Serie temporal del costo de corticosteroides')
plt.xlabel('Fecha')
plt.ylabel('Costo')
plt.legend()
plt.show()

# Ajustar el modelo ETS
model_aaa = sm.tsa.ExponentialSmoothing(monthly_cost, trend='add', seasonal='add', seasonal_periods=12).fit()
model_ann = sm.tsa.ExponentialSmoothing(monthly_cost, trend=None, seasonal=None, seasonal_periods=12).fit()

# Comparar AIC
print(f"AIC del modelo AAA: {model_aaa.aic}")
print(f"AIC del modelo ANN: {model_ann.aic}")

# Pronosticar 24 meses hacia adelante
forecast = model_aaa.forecast(steps=24)

# Graficar la serie temporal con las predicciones
plt.figure(figsize=(10, 6))
plt.plot(monthly_cost, label='Costo mensual')
plt.plot(forecast, label='Pronóstico', color='red')
plt.title('Pronóstico de ventas de corticosteroides en Australia')
plt.xlabel('Fecha')
plt.ylabel('Costo')
plt.legend()
plt.show()
