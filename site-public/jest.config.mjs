import nextJest from 'next/jest.js';

const createJestConfig = nextJest({ dir: './' });

const customJestConfig = {
    setupFilesAfterEnv: ['<rootDir>/jest.setup.js'],
    testEnvironment: 'jest-environment-jsdom',
    moduleNameMapper: {
        '^@components/(.*)$': '<rootDir>/src/app/components/$1',
        '^@sections/(.*)$': '<rootDir>/src/app/sections/$1',
        '^@hooks/(.*)$': '<rootDir>/src/hooks/$1',
        '^@api/(.*)$': '<rootDir>/src/api/$1',
        '^@app/(.*)$': '<rootDir>/src/app/$1',
        '^@assets/(.*)$': '<rootDir>/public/assets/$1',
        '^@generalTypes/(.*)$': '<rootDir>/src/api/types/$1',
        '^@src/(.*)$': '<rootDir>/src/$1',
    },
};

export default createJestConfig(customJestConfig);