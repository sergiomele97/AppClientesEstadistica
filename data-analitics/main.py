from flask import Flask, request, jsonify
from flask_cors import CORS
from statsmodels.tsa.arima.model import ARIMA
from sklearn.cluster import KMeans
from sklearn.metrics import davies_bouldin_score
import warnings

warnings.filterwarnings("ignore", category=UserWarning, module='statsmodels')
app = Flask(__name__)
CORS(app)  # Habilita CORS para todas las rutas

@app.route('/predict', methods=['POST'])
def predict():

    data = request.json
    series = data['data']
    model = ARIMA(series, order=(5, 0, 3))
    model_fit = model.fit()
    pred_steps = 10
    pred = model_fit.get_forecast(steps=pred_steps)
    pred_mean = pred.predicted_mean.tolist()
    pred_ci = pred.conf_int().tolist()
    response = {'Prediction': pred_mean, 'ConfidenceInterval': pred_ci}
    print(response, flush=True)
    return jsonify(response)


@app.route('/cluster', methods=['POST'])
def cluster():

    recibido = request.json
    data = recibido['data']
    print("data es ",data)
    print("data es ",data)
    n_clusters = recibido['nCluster']
    kmeans = KMeans(n_clusters=n_clusters, random_state=0)
    kmeans.fit(data) 
    labels = kmeans.labels_.tolist()
    labels = [lab + 1 for lab in labels]  # Ajuste de etiquetas

    if(n_clusters == 1):
        davies_bouldin = 0.0
    else:
        davies_bouldin = round(davies_bouldin_score(data, kmeans.labels_),2)

    response = {
        "etiqueta": labels,
        "db": davies_bouldin
    }
    print(response, flush=True)
    return jsonify(response)




if __name__ == "__main__":
    app.run(debug=False, host="0.0.0.0", port=8000)
