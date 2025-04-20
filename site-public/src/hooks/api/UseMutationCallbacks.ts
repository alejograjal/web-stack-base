
import { useSnackbar } from '@src/stores/useSnackbar';
import { ErrorDetailsWebStackBase } from '@generalTypes/api-web-stack-base';

export const UseMutationCallbacks = (successMessage: string, onSettledCallback?: () => void) => {
    const setSnackbarMessage = useSnackbar((state) => state.setMessage);

    return {
        onSuccess: () => {
            setSnackbarMessage(successMessage);
        },
        onError: (data: ErrorDetailsWebStackBase) => {
            console.error('Error:', data);
            setSnackbarMessage(`${data.message}`, 'error');
        },
        onSettled: () => {
            onSettledCallback?.();
        },
    };
};