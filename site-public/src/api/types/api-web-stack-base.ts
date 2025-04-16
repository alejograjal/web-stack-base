import { type components } from "@api/web-stack-base/api";

type SchemaTypes = keyof components['schemas'];
export type SchemaData = components['schemas'][SchemaTypes];

export type Resource = components['schemas']['ResponseResourceDto']

export type Service = components['schemas']['ResponseServiceDto']

export type CustomerFeedback = components['schemas']['ResponseCustomerFeedbackDto']
export type CustomerFeedbackRequest = components['schemas']['RequestCustomerFeedbackDto']

