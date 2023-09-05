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
             "--web.console.libraries=/usr/share/prometheus/console_libraries", \
             "--web.console.templates=/usr/share/prometheus/consoles", \
             "--web.external-url=http://localhost:9090" ] 
