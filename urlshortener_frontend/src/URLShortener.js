import "./App.css";
import { useState } from "react";
import FetchedLink from "./FetchedLink";

const URLShortener = () => {

    const [fetchedLink, setFetchedLink] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);

    const [longLink, setLongLink] = useState("");

    const handleSubmit = (e) => {
        e.preventDefault();
        setIsLoading(true);

        const link = { genuineURL: longLink }

        fetch("https://localhost:44380/api/Links", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(link)
        })
            .then((response) => {
                setIsLoading(false);
                return response.json()
            })
            .then((data) => {
                const guid = data.guid;

                fetch(`https://localhost:44380/api/Links/${guid}`)
                    .then((response) => {
                        return response.json()
                    })
                    .then(data => {
                        setFetchedLink(data.shortenedURL)
                    })
            })
            .catch(err => {
                setIsLoading(false);
                setError(err.message);
            })
    }

    return (
        <div className="shortenerAppBox">
            <form onSubmit={handleSubmit}>
                <div className="shortenerContainer">
                    <div className="shortenerInput">
                        <input
                            onChange={(e) => { setLongLink(e.target.value) }}
                            className="inputBox"
                            type="url"
                            placeholder="Provide your long URL here:"
                            required={true}
                            minLength="4"
                        >
                        </input>
                    </div>
                    <div className="shortenerSubmitButton">
                        <button className="btn btn-success"><i class="bi bi-arrows-collapse"></i> Get it shorted!</button>
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