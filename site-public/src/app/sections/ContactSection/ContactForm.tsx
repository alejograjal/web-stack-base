'use client';

import { useState } from "react";
import { yupResolver } from "@hookform/resolvers/yup";
import { Box, Button, TextField } from "@mui/material";
import { FormProvider, useForm } from "react-hook-form";
import { ContactSchema, ContactDefaultValues } from "./ContactSchema";
import { UseMutationCallbacks } from "@hooks/api/UseMutationCallbacks";
import { UsePostContact } from "@hooks/api/web-stack-base/contact/UsePostContact";
import { FormFieldErrorMessage } from "@components/FormFieldErrorMessage/FormFieldErrorMessage";

const ContactForm = () => {
    const [loading, setLoading] = useState(false);

    const cleanForm = () => {
        setLoading(false);
        reset(ContactDefaultValues);
    }

    const formMethods = useForm({
        resolver: yupResolver(ContactSchema),
        defaultValues: ContactDefaultValues
    });

    const {
        register,
        reset,
        handleSubmit,
        formState: { errors },
    } = formMethods;

    const { mutate: postContact } = UsePostContact(UseMutationCallbacks('Thanks for reaching out!', cleanForm));

    const onSubmit = handleSubmit((data) => {
        setLoading(true);
        postContact({ ...data });
    });

    return (
        <Box display="grid" gap={3}>
            <FormProvider {...formMethods}>
                <form onSubmit={onSubmit} noValidate>
                    <Box display="flex" flexDirection="column" gap={3}>
                        <Box>
                            <TextField
                                required
                                error={!!errors.name}
                                label="Name"
                                placeholder="Full name"
                                fullWidth
                                {...register('name')}
                            />
                            {errors.name?.message && (
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
                                {...register('email')}
                            />
                            {errors.email?.message && (
                                <FormFieldErrorMessage message={errors.email.message} />
                            )}
                        </Box>

                        <Box>
                            <TextField
                                required
                                multiline
                                minRows={4}
                                error={!!errors.message}
                                label="Message"
                                placeholder="Write your message here"
                                fullWidth
                                {...register('message')}
                            />
                            {errors.message?.message && (
                                <FormFieldErrorMessage message={errors.message.message} />
                            )}
                        </Box>

                        <Button loading={loading} loadingPosition="start" type="submit" variant="contained">
                            Send message
                        </Button>
                    </Box>
                </form>
            </FormProvider>
        </Box>
    );
};

export default ContactForm;
