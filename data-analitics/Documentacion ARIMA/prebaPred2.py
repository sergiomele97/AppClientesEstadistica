from flask import Flask, request, jsonify
from flask_cors import CORS
from statsmodels.tsa.arima.model import ARIMA
from sklearn.cluster import KMeans
from sklearn.metrics import davies_bouldin_score

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

@app.route('/cluster', methods=['POST'])
def cluster():
    # requestFile: en teoría es un json habrá que leerlo
    data = request.json
    # Aplicar K-means
    kmeans = KMeans(n_clusters=n_clusters, random_state=0)
    kmeans.fit(data)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_

    # Calcular el índice de Davies-Bouldin
    db_score = davies_bouldin_score(data, labels)

    response = {
       "etiqueta": kmeans.labels_, 
       "centros": centers,
       "DB_index": db_score
    }
    return jsonify(response)



if __name__ == "__main__":
    app.run(debug=True)
