'use client';

import { useState } from "react";
import dynamic from "next/dynamic";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormProvider, useForm } from "react-hook-form";
import { ReviewDefaultValues, ReviewSchema } from "./ReviewSchema";
import { UseMutationCallbacks } from "@hooks/api/UseMutationCallbacks";
import { Box, Button, Container, Rating, Typography } from "@mui/material";
import { UsePostReview } from "@hooks/api/web-stack-base/review/UsePostReview";
import { FormFieldErrorMessage } from "@components/FormFieldErrorMessage/FormFieldErrorMessage";


const BaseContact = dynamic(() => import('@components/BaseContact/BaseContactForReview'), {
    ssr: false,
});

const ReviewForm = () => {
    const [loading, setLoading] = useState(false);

    const cleanForm = () => {
        setLoading(false);
        reset(ReviewDefaultValues);
    }

    const formMethods = useForm({
        resolver: yupResolver(ReviewSchema),
        defaultValues: ReviewDefaultValues
    });

    const {
        watch,
        reset,
        register,
        setValue,
        handleSubmit,
        formState: { errors },
    } = formMethods;

    const currentRate = watch('rate');

    const { mutate: postReview } = UsePostReview(UseMutationCallbacks('Thanks for your review', cleanForm));

    const createReviewWrapper = handleSubmit((data) => {
        setLoading(true);
        const formattedData = {
            name: data.name,
            email: data.email,
            comment: data.message,
            rate: data.rate,
        }
        postReview({ ...formattedData });
    });

    return (
        <Container maxWidth="sm">
            <FormProvider {...formMethods}>
                <form onSubmit={createReviewWrapper} noValidate>
                    <Box display="flex" flexDirection="column" gap={3}>

                        <BaseContact register={register} errors={errors} />

                        <Box>
                            <Typography fontWeight="bold" gutterBottom>
                                Your rate:
                            </Typography>
                            <Rating
                                value={currentRate}
                                onChange={(_, value) => setValue('rate', value ?? 0)}
                            />
                            {errors.rate?.message && (
                                <FormFieldErrorMessage message={errors.rate.message} />
                            )}
                        </Box>

                        <Button loading={loading} loadingPosition="start" type="submit" variant="contained">
                            Send review
                        </Button>
                    </Box>
                </form>
            </FormProvider>
        </Container>
    )
}

export default ReviewForm;