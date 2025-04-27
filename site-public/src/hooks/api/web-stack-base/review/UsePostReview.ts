import { ApiError } from "openapi-typescript-fetch";
import { transformErrorKeys } from "@src/util/util";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/api/UseTypedApiClientBS";
import { ErrorDetailsWebStackBase, Review, ReviewRequest } from "@generalTypes/api-web-stack-base";

interface UsePostReviewProps {
    onSuccess?: (
        data: Review,
        variables: ReviewRequest
    ) => void,
    onError?: (
        data: ErrorDetailsWebStackBase,
        variables: ReviewRequest
    ) => void,
    onSettled?: (
        data: Review | undefined,
        error: ErrorDetailsWebStackBase | null,
        variables: ReviewRequest
    ) => void
}

export const UsePostReview = ({
    onSuccess,
    onError,
    onSettled
}: UsePostReviewProps) => {
    const path = '/api/review';
    const method = 'post';

    const postReview = UseTypedApiClientBS({ path, method })
    const queryClient = useQueryClient();

    const createReviewMutation = useMutation({
        mutationKey: ['PostReview'],
        mutationFn: async (holiday: ReviewRequest) => {
            const { data } = await postReview(castRequestBody(holiday, path, method) as never);
            return data;
        },
        onSuccess: async (data: Review, variables: ReviewRequest) => {
            await queryClient.invalidateQueries({
                queryKey: ['GetHoliday']
            })
            onSuccess?.(data, variables)
        },
        onError: (error: ApiError, _) => {
            onError?.(transformErrorKeys(error.data) as ErrorDetailsWebStackBase, _)
        },
        onSettled: (data, error, variables) => {
            onSettled?.(data, error, variables)
        }
    })

    return createReviewMutation;
}