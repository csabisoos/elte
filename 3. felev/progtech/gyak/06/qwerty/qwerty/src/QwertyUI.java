import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class QwertyUI {
    private JFrame frame;
    private JPanel buttonPanel;
    private JTextField textField;
    private JButton[] buttons;

    public QwertyUI() {
        frame = new JFrame("Qwerty");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        buttonPanel = new JPanel();
        buttonPanel.setLayout(new GridLayout(1, 8));
        JButton Qbutton = new JButton("Q");
        Qbutton.addActionListener(new QwertyActionListener("Q"));
        JButton Wbutton = new JButton("W");
        Wbutton.addActionListener(new QwertyActionListener("W"));
        JButton Ebutton = new JButton("E");
        Ebutton.addActionListener(new QwertyActionListener("E"));
        JButton Rbutton = new JButton("R");
        Rbutton.addActionListener(new QwertyActionListener("R"));
        JButton Tbutton = new JButton("T");
        Tbutton.addActionListener(new QwertyActionListener("T"));
        JButton Ybutton = new JButton("Y");
        Ybutton.addActionListener(new QwertyActionListener("Y"));
        JButton Bbutton = new JButton("Backspace");
        Bbutton.addActionListener(new QwertyActionListener("Backspace"));
        JButton CLRbutton = new JButton("CLR");
        CLRbutton.addActionListener(new QwertyActionListener("CLR"));
        buttons = new JButton[] {Qbutton, Wbutton, Ebutton, Rbutton, Tbutton, Ybutton, Bbutton, CLRbutton};

        for (JButton button : buttons) {
            buttonPanel.add(button);
        }

        frame.add(buttonPanel, BorderLayout.SOUTH);
        textField = new JTextField(10);
        frame.add(textField, BorderLayout.NORTH);
        frame.setSize(600, 400);
        frame.pack();
        frame.setVisible(true);


    }

    class QwertyActionListener implements ActionListener {
        private final String message;
        public QwertyActionListener(String message) {
            this.message = message;
        }
        @Override
        public void actionPerformed(ActionEvent e) {
            try {
                switch (message) {
                    /*case "Q":
                        textField.setText(textField.getText() + message);
                        break;
                    case "W":
                        textField.setText(textField.getText() + message);
                        break;
                    case "E":
                        textField.setText(textField.getText() + message);
                        break;
                    case "R":
                        textField.setText(textField.getText() + message);
                        break;
                    case "T":
                        textField.setText(textField.getText() + message);
                        break;
                    case "Y":
                        textField.setText(textField.getText() + message);
                        break;*/
                    case "Backspace":
                        textField.setText(textField.getText().substring(0, textField.getText().length() - 1));
                        break;
                    case "CLR":
                        textField.setText("");
                        break;
                    default:
                        textField.setText(textField.getText() + message);
                        break;
                }
                //textField.setText(textField.getText() + message);
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
    }
}


