import '@testing-library/jest-dom';

Object.defineProperty(window, 'scrollTo', {
    value: () => { },
    writable: true,
});

global.IntersectionObserver = class {
    constructor() { }
    observe() { }
    disconnect() { }
};