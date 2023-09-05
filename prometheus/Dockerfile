FROM prom/prometheus

# copy the Prometheus configuration file
COPY prometheus.yml /etc/prometheus/prometheus.yml

# set environment variables
ENV TZ=Asia/Kolkata

# expose the Prometheus server port
EXPOSE 9090

# set the entrypoint command
ENTRYPOINT [ "prometheus", \
             "--config.file=/etc/prometheus/prometheus.yml", \
             "--storage.tsdb.path=/prometheus", \
             "--storage.tsdb.retention=365d", \
             "--web.external-url=http://localhost:9090" ] 
