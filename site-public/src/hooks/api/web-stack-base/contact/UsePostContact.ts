
import { ApiError } from "openapi-typescript-fetch";
import { transformErrorKeys } from "@src/util/util";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/api/UseTypedApiClientBS";
import { ErrorDetailsWebStackBase, ContactRequest } from "@generalTypes/api-web-stack-base";

interface UsePostContactProps {
    onSuccess?: (
        data: boolean,
        variables: ContactRequest
    ) => void,
    onError?: (
        data: ErrorDetailsWebStackBase,
        variables: ContactRequest
    ) => void,
    onSettled?: (
        data: boolean | undefined,
        error: ErrorDetailsWebStackBase | null,
        variables: ContactRequest
    ) => void
}

export const UsePostContact = ({
    onSuccess,
    onError,
    onSettled
}: UsePostContactProps) => {
    const path = '/api/contact';
    const method = 'post';

    const postContact = UseTypedApiClientBS({ path, method })
    const queryClient = useQueryClient();

    const createContactMutation = useMutation({
        mutationKey: ['PostContact'],
        mutationFn: async (holiday: ContactRequest) => {
            const { data } = await postContact(castRequestBody(holiday, path, method) as never);
            return data;
        },
        onSuccess: async (data: boolean, variables: ContactRequest) => {
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

    return createContactMutation;
}