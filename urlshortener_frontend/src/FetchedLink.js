const FetchedLink = (props) => {

    const HandleClick = (e) => {
        e.preventDefault();
        navigator.clipboard.writeText(props.link)
        const copyButton = document.querySelector("#copyButton");
        copyButton.className = 'btn btn-success';
        copyButton.innerHTML = '<i class="bi bi-check-lg"></i> Copy';
        //// ONLY FOR PRESENTATION PUSPOSES !!!
        setTimeout(() => {
            copyButton.className = 'btn btn-primary';
            copyButton.innerHTML = '<i class="bi bi-files"></i> Copy';
        }, 1700);
        ////
    }
    return (<div>
        <div className="dropdown-divider"></div>
        
        <div className="shortenerContainer">
            <div className="yourLink">
                Your new link <i className="margLeft bi bi-arrow-right"></i>
            </div>
                <div className="inputBoxFetchedLink">
                    {props.link}
                
            </div>
            
            <div className="shortenerSubmitButton">
                <button onClick={HandleClick} className="btn btn-primary" id="copyButton"><i className="bi bi-files"></i> Copy</button>
            </div>
        </div>
    </div>
    );
}

export default FetchedLink;