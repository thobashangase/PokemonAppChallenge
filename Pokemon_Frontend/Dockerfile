### STAGE 1: Build ###
FROM node:16.13.0-alpine AS builder

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install

COPY . .

RUN npm run build

### STAGE 2: Run ###
FROM nginx:alpine
VOLUME /var/cache/nginx

COPY --from=builder /app/dist/pokemon-frontend/* /usr/share/nginx/html/
COPY nginx/default.conf /etc/nginx/conf.d/default.conf