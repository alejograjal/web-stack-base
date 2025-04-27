import { ApiError } from "openapi-typescript-fetch";
import { Review } from "@api/types/api-web-stack-base";
import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/api/UseTypedApiClientBS";

export const UseGetReviews = (): UseQueryResult<Array<Review>, ApiError> => {
    const path = '/api/review';
    const method = 'get';

    const getReviews = UseTypedApiClientBS({ path, method })

    return useQuery({
        queryKey: ["GetReviews"],
        queryFn: async () => {
            const { data } = await getReviews(castRequestBody({}, path, method));
            return data
        },
        enabled: true,
        staleTime: 0,
    })
}