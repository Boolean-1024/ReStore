import { AppBar, Switch, Toolbar, Typography } from "@mui/material";

interface Props {
    darkMode: boolean;
    setDarkMode: (darkMode: boolean) => void

}
export default function Header({ darkMode, setDarkMode }: Props) {
    return (
        <AppBar position='static' sx={{ mb: 4 }}>
            <Toolbar>
                <Switch checked = {darkMode} onChange={() => {setDarkMode(!darkMode)}}/>

                <Typography variant='h6'>
                    RE-STORE
                </Typography>
            </Toolbar>

        </AppBar>
    )
}