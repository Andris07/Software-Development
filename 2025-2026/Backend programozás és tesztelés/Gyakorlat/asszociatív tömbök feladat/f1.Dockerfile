FROM php:8.4.8-cli-alpine3.22

WORKDIR /app

RUN apk add --no-cache bash
COPY f1.php /app/f1.php
COPY versenyzok.php /app/versenyzok.php
ENTRYPOINT ["php", "f1.php"]