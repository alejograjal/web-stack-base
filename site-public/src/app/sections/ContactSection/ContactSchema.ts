import { object, string, type InferType } from "yup";

export const ContactDefaultValues = {
    name: '',
    email: '',
    message: '',
};

export const ContactSchema = object().shape({
    name: string().required('Name is required').max(100, 'Name must be at most 100 characters'),
    email: string()
        .required('Email is required')
        .email('Email must be a valid email address')
        .max(150, 'Email must be at most 150 characters'),
    message: string().required('Message is required').max(500, 'Message must be at most 500 characters')
})

export type BranchForm = InferType<typeof ContactSchema>