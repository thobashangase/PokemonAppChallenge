FROM node:16.13.0-alpine AS builder

WORKDIR /app

COPY . .

ARG BUILDCONF

RUN npm install && \
npm run build

FROM nginx:alpine
VOLUME /var/cache/nginx

COPY --from=builder /app/dist/Pokemon_Frontend/* /usr/share/nginx/html/
COPY nginx/default.conf /etc/nginx/conf.d/default.conf