import { ApiError } from "openapi-typescript-fetch";
import { Service } from "@generalTypes/api-web-stack-base";
import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/UseTypedApiClientBS";
export const UseGetServices = (): UseQueryResult<Array<Service>, ApiError> => {
    const path = '/api/service';
    const method = 'get';

    const getBranches = UseTypedApiClientBS({ path, method })

    return useQuery({
        queryKey: ["GetServices"],
        queryFn: async () => {
            const { data } = await getBranches(castRequestBody({}, path, method));
            return data
        },
        enabled: true,
        staleTime: 0,
    })
}
