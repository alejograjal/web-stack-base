import { number, object, type InferType } from "yup";
import { ContactDefaultValues, ContactSchema } from "@sections/ContactSection/ContactSchema";

export const ReviewDefaultValues = {
    ...ContactDefaultValues,
    rate: 0,
};

export const ReviewSchema = ContactSchema.concat(object().shape({
    rate: number()
        .required('Rate is required')
        .min(1, 'Rate must be at least 1')
        .max(5, 'Rate must be at most 5'),
}));

export type ReviewForm = InferType<typeof ReviewSchema>