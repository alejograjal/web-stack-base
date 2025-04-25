import { ApiError } from "openapi-typescript-fetch";
import { ErrorDetailsWebStackBase } from "@api/types/api-web-stack-base";

export const isPresent = <T>(t: T): t is NonNullable<T> => {
    return t !== null && t !== undefined;
};

const toCamelCase = (str: string): string => {
    return str.replace(/([A-Z])/g, (match) => `_${match.toLowerCase()}`).replace(/^_/, "");
};

export const transformErrorKeys = (error: Record<string, unknown>): Record<string, unknown> => {
    const transformedError: Record<string, unknown> = {};
    for (const key in error) {
        if (Object.prototype.hasOwnProperty.call(error, key)) {
            transformedError[toCamelCase(key)] = error[key];
        }
    }
    return transformedError;
};

export const getErrorMessage = (error: ApiError) => {
    const errorDetail = transformErrorKeys(error.data as ErrorDetailsWebStackBase);
    return errorDetail.message;
}

export const isNil = (value: unknown): value is null | undefined => value === null || value === undefined;