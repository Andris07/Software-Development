FROM php:8.4.8-cli-alpine3.22

WORKDIR /app
COPY . /app

RUN apk add --no-cache bash

ENTRYPOINT ["php", "heroes.php"]