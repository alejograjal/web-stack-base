import { ApiError } from "openapi-typescript-fetch";
import { Service } from "@api/types/api-web-stack-base";
import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/api/UseTypedApiClientBS";

export const UseGetServices = (): UseQueryResult<Array<Service>, ApiError> => {
    const path = '/api/service';
    const method = 'get';

    const getServices = UseTypedApiClientBS({ path, method })

    return useQuery({
        queryKey: ["GetServices"],
        queryFn: async () => {
            const { data } = await getServices(castRequestBody({}, path, method));
            return data
        },
        enabled: true,
        staleTime: 0,
    })
}