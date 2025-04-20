'use client';

import { useState } from "react";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormProvider, useForm } from "react-hook-form";
import { ReviewDefaultValues, ReviewSchema } from "./ReviewSchema";
import { UseMutationCallbacks } from "@hooks/api/UseMutationCallbacks";
import { UsePostReview } from "@hooks/api/web-stack-base/review/UsePostReview";
import { Box, Button, Container, Rating, TextField, Typography } from "@mui/material";
import { FormFieldErrorMessage } from "@components/FormFieldErrorMessage/FormFieldErrorMessage";


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
                                multiline
                                minRows={3}
                                error={!!errors.message}
                                label="Comments"
                                placeholder="Write your review here"
                                fullWidth
                                {...register('message')}
                            />
                            {errors.message?.message && (
                                <FormFieldErrorMessage message={errors.message.message} />
                            )}
                        </Box>

                        <Box>
                            <Typography fontWeight="bold" gutterBottom>
                                Your rate:
                            </Typography>
                            <Rating
                                value={currentRate}
                                onChange={(_, value) => setValue('rate', value || 0)}
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