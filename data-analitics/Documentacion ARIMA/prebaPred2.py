from flask import Flask, request, jsonify
from flask_cors import CORS
from statsmodels.tsa.arima.model import ARIMA

app = Flask(__name__)
CORS(app)  # Habilita CORS para todas las rutas

@app.route('/predict', methods=['POST'])
def predict():
    data = request.json
    series = data['series']

    # Ajustar el modelo ARIMA
    model = ARIMA(series, order=(5, 0, 3))
    model_fit = model.fit()

    # Hacer predicciones
    pred_steps = 10
    pred = model_fit.get_forecast(steps=pred_steps)
    pred_mean = pred.predicted_mean.tolist()
    pred_ci = pred.conf_int().tolist()

    response = {
        'Prediction': pred_mean,
        'ConfidenceInterval': pred_ci
    }
    
    return jsonify(response)

if __name__ == "__main__":
    app.run(debug=True)
