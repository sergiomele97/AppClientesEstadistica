#from flask import Flask, request, jsonify
#from flask_cors import CORS
import flask_cors as fc
from statsmodels.tsa.arima.model import ARIMA
#from sklearn.cluster import KMeans
import sklearn.cluster as sc
#from sklearn.metrics import davies_bouldin_score
import sklearn.metrics as sm
import warnings
import numpy as np
import flask as f
warnings.filterwarnings("ignore", category=UserWarning, module='statsmodels')
app = f.Flask(__name__)
fc.CORS(app)  # Habilita CORS para todas las rutas
@app.route('/predict', methods=['POST'])
def predict():

    data = f.request.json
    series = data['data']
    model = ARIMA(series, order=(5, 0, 3))
    model_fit = model.fit()
    pred_steps = 10
    pred = model_fit.get_forecast(steps=pred_steps)
    pred_mean = pred.predicted_mean.tolist()
    pred_ci = pred.conf_int().tolist()
    response = {'Prediction': pred_mean, 'ConfidenceInterval': pred_ci}
    print(response, flush=True)
    return f.jsonify(response)


@app.route('/cluster', methods=['POST'])
def cluster():

    recibido = f.request.json
    data = recibido['data']
    print("data es ",data)
    print("data es ",data)
    n_clusters = recibido['nCluster']
    kmeans = sc.KMeans(n_clusters=n_clusters, random_state=0)
    kmeans.fit(data)
    labels = kmeans.labels_.tolist()
    labels = [lab + 1 for lab in labels]  # Ajuste de etiquetas

    if(n_clusters == 1):
        davies_bouldin = 0.0
    else:
        davies_bouldin = np.round(sm.davies_bouldin_score(data, kmeans.labels_),2)

    response = {
        "etiqueta": labels,
        "db": davies_bouldin
    }
    print(response, flush=True)
    return f.jsonify(response)




if __name__ == "__main__":
    app.run(debug=True)
