import numpy as np
import matplotlib.pyplot as plt
from sklearn.datasets import make_blobs
from sklearn.cluster import KMeans
from sklearn.metrics import davies_bouldin_score

# Crear un pequeño conjunto de datos
n_samples = 300
n_features = 4
n_clusters = 3

X, _ = make_blobs(n_samples=n_samples, n_features=n_features, centers=n_clusters, cluster_std=0.60, random_state=0)
def kmeansPrueba(X, n_clusters):
    # Aplicar K-means
    kmeans = KMeans(n_clusters=n_clusters, random_state=0)
    kmeans.fit(X)
    labels = kmeans.labels_
    centers = kmeans.cluster_centers_

    # Calcular el índice de Davies-Bouldin
    db_score = davies_bouldin_score(X, labels)

        # Graficar los resultados
    plt.figure(figsize=(8, 6))
    plt.scatter(X[:, 0], X[:, 1], c=labels, s=50, cmap='viridis')
    plt.scatter(centers[:, 0], centers[:, 1], c='red', s=200, alpha=0.75, marker='X')
    plt.title(f'K-means Clustering\nDavies-Bouldin Index: {db_score:.2f}')
    plt.xlabel('Feature 1')
    plt.ylabel('Feature 2')
    plt.show()

    return kmeans.labels_, centers, db_score


kmeansPrueba(X,n_clusters)