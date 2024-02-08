import { useCallback, useState } from "react"

const baseUrl = 'https://localhost:7194/';

const useHttps = (config) => {
    const [errorMessage, setErrorMessage] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    const sendRequest = useCallback(async (config, handleResponse) => {
        try {
            setErrorMessage('');
            setIsLoading(true)

            var response = await fetch(`${baseUrl}${config.url}`, {
                method: config.method,
                body: JSON.stringify(config.value),
                headers: { 'Content-Type': 'application/json' }
            });

            if (!response.ok) {
                throw new Error("There was an unexpected error.")
            }

            var responseData = await response.json();

            if (handleResponse instanceof Function) {
                handleResponse(responseData);
            }
        }
        catch (error) {
            setErrorMessage("There was an unexpexted error! Please try again!");
        }
        finally {
            setIsLoading(false);
        }
    }, [])

    return {
        sendRequest,
        isLoading,
        errorMessage,
    }
}

export default useHttps;