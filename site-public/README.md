# 📦 site-public

This directory contains the frontend of the web-stack-base project, a modern foundation for web applications built with Next.js, TypeScript, and Docker (as an optional deployment method). It is designed to streamline the development, testing, and deployment of scalable web applications.

## 🚀 Tecnologías Utilizadas

- Next.js 14
- TypeScript
- Docker
- ESLint
- PostCSS
- Geist Font

## 🛠️ Instalación y Ejecución

### Prerequisites  
- Make sure api is running, please learn how to execute it
- Node.js (+v18)
- npm
- Docker and Docker Compose (optional for containers)

### Steps to Start the Project
1. Clone repository

```bash
git clone https://github.com/alejograjal/web-stack-base.git
cd web-stack-base/site-public
```

2. Move or open to folder `site-public`

3. Install dependencies

```bash
npm install
````

4. Add env variable `NEXT_PUBLIC_API_WEB_STACK_BASE_URL` with the url of the api running

5. Run development locally

```bash
npm run dev
```

6. Open your browser in http://localhost:3000 to check functionality.

## 🐳 Docker use

### To execute project in a docker container

```bash
docker-compose up --build
````

This will run the site in http://localhost:3000.

## 📁 Project Structure

```bash
site-public/
├── public/               # Static files
├── src/                  # Main source code
│   └── app/              # Next.js pages and components
├── Dockerfile            # Docker configuration
├── docker-compose.yml    # Container orchestration
├── package.json          # Dependencies and scripts
├── tsconfig.json         # TypeScript configuration
├── next.config.ts        # Next.js configuration
└── README.md             # Project documentation
````

## 📚 Additional Resources

- [Next.js Documentation](https://nextjs.org/docs)
- [TypeScript Guide](https://www.typescriptlang.org/docs/)
- [Docker Guide](https://docs.docker.com/get-started/)