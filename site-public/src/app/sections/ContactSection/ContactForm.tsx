'use client';

import { useState } from "react";
import dynamic from 'next/dynamic';
import { Box, Button } from "@mui/material";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormProvider, useForm } from "react-hook-form";
import { ContactSchema, ContactDefaultValues } from "./ContactSchema";
import { UseMutationCallbacks } from "@hooks/api/UseMutationCallbacks";
import { UsePostContact } from "@hooks/api/web-stack-base/contact/UsePostContact";

const BaseContact = dynamic(() => import('@components/BaseContact/BaseContact'), {
    ssr: false,
});

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

                        <BaseContact register={register} errors={errors} />

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
