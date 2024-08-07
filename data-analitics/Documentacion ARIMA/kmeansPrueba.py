import sys
import json
from sklearn.datasets import make_blobs
from sklearn.cluster import KMeans
from sklearn.metrics import davies_bouldin_score

def main(requestFile, response_file, n_clusters):
    # requestFile: en teoría es un json habrá que leerlo
    X = requestFile
    # Aplicar K-means
    kmeans = KMeans(n_clusters=n_clusters, random_state=0)
    kmeans.fit(X)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_

    # Calcular el índice de Davies-Bouldin
    db_score = davies_bouldin_score(X, labels)

    response = {
       "etiqueta": kmeans.labels_, 
       "centros": centers,
       "DB_index": db_score
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