FROM php:8.4.8-cli-alpine3.22

WORKDIR /app

RUN apk add --no-cache bash
COPY jaratok.php /app/jaratok.php
COPY repter.php /app/repter.php
ENTRYPOINT ["php", "repter.php"]