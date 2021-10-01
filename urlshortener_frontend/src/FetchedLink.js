const FetchedLink = (props) => {
    return ( <div>
        <div className="dropdown-divider">a</div>
        <div className="shortenerContainer">
                    <div className="shortenerInput">
                        <div className="inputBox">
                        { props.link }
                            </div>
                    </div>
                    <div className="shortenerSubmitButton">
                        <button className="btn btn-primary"><i class="bi bi-files"></i> Copy</button>
                    </div>
                </div>      
                </div>
     );
}
 
export default FetchedLink;