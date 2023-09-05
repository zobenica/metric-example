FROM grafana/grafana

COPY provisioning/ /etc/grafana/provisioning/
      
ENV GF_SECURITY_ADMIN_PASSWORD=Lozinka5#

EXPOSE 3000

ENTRYPOINT [ "/run.sh" ] 
