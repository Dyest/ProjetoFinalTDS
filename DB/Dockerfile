FROM mysql:8.0.33

ENV MYSQL_ROOT_PASSWORD=delivery
ENV MYSQL_DATABASE=delivery

COPY ./scripts/ /docker-entrypoint-initdb.d/

EXPOSE 3306


