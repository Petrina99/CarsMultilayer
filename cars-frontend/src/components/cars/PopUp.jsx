import './styles/popup.css';

export const PopUp = ({ message, handleDelete, handleClose, car }) => {

    const handleConfirm = () => {
        handleDelete(car.id);
        handleClose();
    }

    return (
        <div className="modal">
            <div className="popup-div">
                <p>{message}</p>
                <div className='popup-buttons'>
                    <button onClick={handleConfirm}>Ok</button>
                    <button onClick={handleClose}>Cancel</button>
                </div>
            </div>
        </div>
    )
}