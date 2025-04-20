import { type components } from "@api/clients/web-stack-base/api";

type SchemaTypes = keyof components['schemas'];
export type SchemaData = components['schemas'][SchemaTypes];

export type Resource = components['schemas']['ResponseResourceDto']

export type Service = components['schemas']['ResponseServiceDto']

export type Review = components['schemas']['ResponseReviewDto']
export type ReviewRequest = components['schemas']['RequestReviewDto']

export type ContactRequest = components['schemas']['RequestContactDto']

export type ErrorDetailsWebStackBase = components['schemas']['ErrorDetailsWebStackBase']