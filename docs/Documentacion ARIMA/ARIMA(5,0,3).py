import pandas as pd
from statsmodels.tsa.holtwinters import ExponentialSmoothing
import numpy as np 
import matplotlib.pyplot as plt
from statsmodels.tsa.arima.model import ARIMA

np.random.seed(0)
date_range = pd.date_range(start='2023-01-01', periods=200, freq='D')
values = np.random.normal(loc=1.1, scale=0.01, size=len(date_range))

df = pd.DataFrame({'fecha': date_range, 'valor': values})


# Asegúrate de que los datos estén ordenados por fecha
df = df.sort_index()

# Extraemos la serie temporal de los valores
ts = df['valor']
model = ARIMA(ts, order=(5, 0, 3))
model_fit = model.fit()

# Hacer predicciones para los próximos días con intervalos de confianza
pred_steps = 10
pred = model_fit.get_forecast(steps=pred_steps)
pred_mean = pred.predicted_mean
pred_ci = pred.conf_int()

# Mostrar las predicciones
print(pred_mean)
print(pred_ci)

# Visualizar los resultados
plt.figure(figsize=(10, 6))
plt.plot(ts, label='Datos históricos')
plt.plot(pred_mean, color='red', label='Predicciones')
plt.fill_between(pred_ci.index, pred_ci.iloc[:, 0], pred_ci.iloc[:, 1], color='red', alpha=0.3, label='Intervalo de confianza')
plt.legend()
plt.xlabel('Fecha')
plt.ylabel('Valor')
plt.title('Predicciones con ARIMA')
plt.show()