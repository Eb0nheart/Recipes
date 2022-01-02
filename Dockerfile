FROM node:17

WORKDIR /usr/src/recipes

EXPOSE 3000

COPY package*.json ./

RUN npm install

COPY . . 

CMD ["npm", "start"]