# Use an official Node.js image as the base
FROM node:20-alpine

# Create and set the working directory
WORKDIR /app

# Copy the necessary files to the container
COPY package*.json ./

# Install the dependencies
RUN npm install

# Copy the rest of the project to the container
COPY . .

# Build the Next.js app
RUN npm run build

# Expose the port on which the app will run
EXPOSE 3000

# Define the command to start the app
CMD ["npm", "start"]
