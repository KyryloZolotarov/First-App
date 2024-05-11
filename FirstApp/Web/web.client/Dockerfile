# Stage 1: Build the Angular application
FROM node as build
WORKDIR /app
COPY Web/web.client/ ./
RUN npm install
RUN npm run build -- --configuration production

# Stage 2: Use Nginx to serve the built Angular app
FROM nginx:alpine
COPY --from=build /app/dist/out/ /usr/share/nginx/html
COPY Web/web.client/nginx/nginx.conf /etc/nginx/conf.d/default.conf
