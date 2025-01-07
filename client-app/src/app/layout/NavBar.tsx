import { Button, Container, Menu } from "semantic-ui-react"; // Importing components from Semantic UI React library


interface Props { // Defining the type for the component props
    openForm: () => void; // Function to open the form
}

export default function NavBar({ openForm }: Props) { // Functional component receiving openForm as a prop
    return (
        <Menu inverted fixed='top'> {/* Semantic UI Menu component with inverted color and fixed to the top */}
            <Container> {/* Semantic UI Container to center the content */}
                <Menu.Item header> {/* Header item in the menu */}
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: 10 }} /> {/* Logo with margin on the right */}
                    Social App {/* App name displayed in the header */}
                </Menu.Item>
                <Menu.Item name='Products' /> {/* Static menu item for "Products" */}
                <Menu.Item> {/* Menu item to hold the "Create Products" button */}
                    <Button onClick={openForm} positive content='Create Products' /> {/* Button with positive styling to trigger openForm */}
                </Menu.Item>
            </Container>
        </Menu>
    )
}