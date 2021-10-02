import { useEffect } from "react";
import { useState } from "react";

const useApiGet = (url) => {

    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        console.log("apiGet RUN!")
        fetch(url)
        .then((response) => {
            return response.json()
        })
        .then(data => {
            setData(data.genuineURL)
            setIsLoading(false);
            setError(null);
            console.log("api:"+data.genuineURL)

        })
        .catch((err) => {
            setIsLoading(false);
            setError(err.message);
        })
        return () => {
            console.log("cleanup")
        }
    }, []);

    return { data, isLoading, error }
}
 
export default useApiGet;