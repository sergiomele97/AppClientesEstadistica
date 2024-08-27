# gunicorn.conf.py

bind = "0.0.0.0:8000"  # Asegúrate de que el puerto coincide con el puerto en el que Azure espera que esté escuchando tu aplicación.
workers = 1
timeout = 60# gunicorn.conf.py

