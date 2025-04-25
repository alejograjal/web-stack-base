import { Box, TextField } from '@mui/material';
import { UseFormRegister, FieldErrors, Path } from 'react-hook-form';
import { FormFieldErrorMessage } from '@components/FormFieldErrorMessage/FormFieldErrorMessage';

export interface RequiredFields {
    name: string;
    email: string;
    message: string;
}

export interface BaseContactProps<T extends RequiredFields> {
    register: UseFormRegister<T>;
    errors: FieldErrors<T>;
}

const BaseContact = <T extends RequiredFields>({
    register,
    errors,
}: BaseContactProps<T>) => {
    return (
        <>
            <Box>
                <TextField
                    required
                    error={!!errors.name}
                    label="Name"
                    placeholder="Full name"
                    fullWidth
                    {...register('name' as Path<T>)}
                />
                {typeof errors.name?.message === 'string' && (
                    <FormFieldErrorMessage message={errors.name.message} />
                )}
            </Box>

            <Box>
                <TextField
                    required
                    error={!!errors.email}
                    label="Email"
                    placeholder="Email"
                    fullWidth
                    {...register('email' as Path<T>)}
                />
                {typeof errors.email?.message === 'string' && (
                    <FormFieldErrorMessage message={errors.email.message} />
                )}
            </Box>

            <Box>
                <TextField
                    multiline
                    minRows={3}
                    error={!!errors.message}
                    label="Comments"
                    placeholder="Write your review here"
                    fullWidth
                    {...register('message' as Path<T>)}
                />
                {typeof errors.message?.message === 'string' && (
                    <FormFieldErrorMessage message={errors.message.message} />
                )}
            </Box>
        </>
    );
};

export default BaseContact;