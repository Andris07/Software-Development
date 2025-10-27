FROM php:8.4.8-cli-alpine3.22

WORKDIR /app

RUN apk add --no-cache bash
COPY . /en.php
COPY . /bemutatkozo.php
ENTRYPOINT ["php", "bemutatkozo.php"]