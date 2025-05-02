import { ApiError } from "openapi-typescript-fetch";
import { Resource } from "@api/types/api-web-stack-base";
import { useQuery, UseQueryResult } from "@tanstack/react-query";
import { castRequestBody, UseTypedApiClientBS } from "@hooks/api/UseTypedApiClientBS";

const UseGetResources = (resourceTypeId?: number, enabled?: boolean): UseQueryResult<Array<Resource>, ApiError> => {
    const path = '/api/resource';
    const method = 'get';

    const getResources = UseTypedApiClientBS({ path, method })

    return useQuery({
        queryKey: ["GetResources", resourceTypeId],
        queryFn: async () => {
            const { data } = await getResources(castRequestBody({ resourceTypeId: resourceTypeId }, path, method));
            return data
        },
        enabled: enabled ?? true,
        staleTime: 0,
    })
}

export default UseGetResources;