import React from "react";
import { useParams } from "react-router";
import useApiGet from "./useApiGet";

const RedirectComponent = () => {

    const BASE_URL = "https://localhost:44380/api/Links/";

    const { guid } = useParams();
    const url = `${BASE_URL}${guid}`;
    const { data, isLoading, error } = useApiGet(url);

    return (
        <div>
            { error && <h3>{ error }</h3> }
            { isLoading && <div className="text-center"><div className="loading spinner-border"></div></div> }
            { data && window.location.replace(data) }
        </div>
    );
}

export default RedirectComponent;