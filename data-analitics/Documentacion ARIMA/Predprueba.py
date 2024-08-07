from statsmodels.tsa.arima.model import ARIMA
import sys
import json
import numpy as np

def main(requestFile, response_file):
    # requestFile: Se le envía desde C# python la serie temporal de la que se quiere hacer la predicción
    ts = requestFile.data
    
    model = ARIMA(ts, order=(5, 0, 3))  # Hacemos el modelo
    model_fit = model.fit()

    # Hacer predicciones para los próximos días con intervalos de confianza
    pred_steps = 10
    pred = model_fit.get_forecast(steps=pred_steps)  # Predicción a 10 días
    pred_mean = pred.predicted_mean.tolist()  # Media de la predicción
    pred_ci = pred.conf_int().tolist()  # Intervalo de confianza

    response = {
        'Prediction': np.concatenate([ts, pred_mean]),
        'ConfidenceInterval': pred_ci
    }

    # Escribir resultados en el archivo temporal
    with open(response_file, 'w') as f:
        json.dump(response, f)







if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("Usage: script.py <requestFile> <response_file>")
        sys.exit(1)

    request_file = sys.argv[1]
    response_file = sys.argv[2]

    with open(request_file, 'r') as f:
        data = json.load(f)
    
    requestFile = data['series']
    main(requestFile, response_file)