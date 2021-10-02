import "./App.css";
import { useState } from "react";
import FetchedLink from "./FetchedLink";

const URLShortener = () => {

    const BASE_URL = "https://localhost:44380/api/Links/";

    const [fetchedLink, setFetchedLink] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [longLink, setLongLink] = useState("");

    const handleClear = () => {
        const input = document.querySelector("#urlInput");
        input.value = null;
    }

    const handleRefresh = () => {
        window.location.reload(false);
    }
    const handleSubmit = (e) => {
        e.preventDefault();
        setIsLoading(true);
        const link = { genuineURL: longLink }

        fetch(BASE_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(link)
        })
            .then((response) => {
                return response.json()
            })
            .then((data) => {
                const guid = data.guid;
                fetch(`${BASE_URL}${guid}`)
                    .then((response) => {
                        return response.json()
                    })
                    .then(data => {
                        setIsLoading(false);
                        setFetchedLink(data.shortenedURL)
                    })
            })
            .catch(err => {
                setIsLoading(false);
                setError(err.message);
            })
    };

    return (
        <div className="shortenerAppBox">

            <form onSubmit={handleSubmit}>
                <div className="shortenerContainer">
                    <div className="shortenerInput">
                        <div className="title">
                            SHORTEN YOUR URL
                        </div>
                    </div>
                    <button type="button" className="refreshBtn btn btn-sm btn-light" onClick={handleClear}>
                        <i class="bi bi-arrow-repeat"></i> Clear
                    </button>
                    <button type="button" className="refreshBtn btn btn-sm btn-light" onClick={handleRefresh}>
                        <i class="bi bi-arrow-repeat"></i> Refresh  
                    </button>
                </div>
                <div className="dropdown-divider"></div>
                <div className="shortenerContainer">
                    <div className="shortenerInput">
                        <input
                            onChange={(e) => { setLongLink(e.target.value) }}
                            className="inputBox"
                            type="url"
                            placeholder="Paste your long URL here:"
                            required={true}
                            minLength="4"
                            id="urlInput">
                        </input>
                    </div>
                    <div className="shortenerSubmitButton">
                        <button className="btn btn-success"><i class="bi bi-arrows-collapse"></i> Get it shorted !</button>
                    </div>
                </div>
            </form>

            {isLoading && <div className="text-center"><div className="loading spinner-border"></div></div>}
            {fetchedLink && <div> <FetchedLink link={fetchedLink} /> </div>}
            {error && <div>{error}</div>}

        </div>
    );
}

export default URLShortener;