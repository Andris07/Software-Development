FROM php:8.4-cli-alpine3.22

WORKDIR /app

RUN apk add --no-cache bash
COPY . /app

ENTRYPOINT ["./idezetek.php"]