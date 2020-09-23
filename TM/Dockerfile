#stage1
FROM node:12.18.4 AS ng-build-stage

WORKDIR /TM

COPY package.json package-lock.json ./
RUN npm install

COPY . .

RUN npm run build

#stage2
FROM nginx:latest
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=ng-build-stage TM/dist/TM /usr/share/nginx/html